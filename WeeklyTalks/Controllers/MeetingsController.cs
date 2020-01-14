using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeeklyTalks.Dtos;
using WeeklyTalks.Helpers;
using WeeklyTalks.Models;

namespace WeeklyTalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly db_weeklytalksContext _context;
        private IMapper _mapper;
        private IHostingEnvironment _env;

        public MeetingsController(db_weeklytalksContext context, IMapper mapper, IHostingEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        // GET: api/Meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meetings>>> GetMeetings([FromQuery] int officeId)
        {
            var meetings = await _context.Meetings.Where(m => m.OfficeId == officeId).ToListAsync();

            if (meetings == null)
            {
                return NotFound();
            }

            return meetings;
        }

        // GET: api/Meetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meetings>> GetMeetings(long id)
        {
            var meetings = await _context.Meetings.FindAsync(id);

            if (meetings == null)
            {
                return NotFound();
            }

            return meetings;
        }

        // PUT: api/Meetings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetings(long id, [FromBody]Meetings meetings)
        {
            if (id != meetings.Id)
            {
                return BadRequest();
            }

            _context.Entry(meetings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Meetings
        
        [HttpPost]
        public IActionResult CreateMeetings([FromBody]CreateMeetingDto createMeetingDto)
        {
            

            if (createMeetingDto.Quantity == "one")
            {
                var meeting = _mapper.Map<Meetings>(createMeetingDto);
                _context.Meetings.Add(meeting);
                _context.SaveChanges();
                

            }
            else if (createMeetingDto.Quantity == "all")
            {
                var offices = _context.Offices;

                foreach (Offices o in offices)
                {
                    var meeting = _mapper.Map<Meetings>(createMeetingDto);
                    meeting.OfficeId = Convert.ToInt32(o.Id);
                    _context.Meetings.Add(meeting);
                }
                _context.SaveChanges();

            }
            else
            {
                throw new AppException("Offices quantity is required");
            }
            return Ok();
        }

        // DELETE: api/Meetings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meetings>> DeleteMeetings(long id)
        {
            var meetings = await _context.Meetings.FindAsync(id);
            if (meetings == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meetings);
            await _context.SaveChangesAsync();

            return meetings;
        }

        [HttpGet("{id}/user")]
        public Meetings GetMeetingByUser(long id, [FromQuery]DateTime startDate)
        {
            var user = _context.Users.Find(id);

            int officeId = user.OfficeId.Value;

            var meeting = _context.Meetings
                .Where(m => m.OfficeId == officeId && m.StartDate.Date == startDate.Date).FirstOrDefault();

            return meeting;
        }
        
        [HttpPost("{id}/attendance")]
        public IActionResult RegisterAttendance(long id, [FromBody]StoreAttendanceMeetingDto attendance)
        {

            var dir = _env.WebRootPath;
            var meeting = _context.Meetings.Find(id);
            List<string> filenames = new List<string>();

            if (meeting.Status == 0)
            {
                foreach (var file in attendance.Captures)
                {
                    var fn = Path.GetRandomFileName();
                    string convertedfile = file.Replace("data:image/png;base64,", String.Empty);
                    var imageDataByteArray = Convert.FromBase64String(convertedfile);

                    var imageDataStream = new MemoryStream(imageDataByteArray) { Position = 0 };

                    using (var fileStream = new FileStream(Path.Combine(dir, "pictures", $"{fn}.png"), FileMode.Create, FileAccess.Write))
                    {
                        imageDataStream.CopyTo(fileStream);
                        filenames.Add(fn);
                    }
                }

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var currentTime = DateTime.Now;
                        if (meeting.EndDate >= DateTime.Now)
                        {
                            meeting.StatusDescription = "Temprano";
                        }
                        else
                        {
                            meeting.StatusDescription = "Tarde";
                        }
                        meeting.DocumentPic = $"{filenames[0]}.png";
                        meeting.SelfiePic = $"{filenames[1]}.png";
                        meeting.Status = 1;
                        meeting.UpdatedAt = DateTime.Now;
                        _context.SaveChanges();

                        var employees = _context.Employees;

                        foreach (EmployeeAttendanceDto e in attendance.EmployeesList)
                        {
                            var em = new EmployeeMeeting
                            {
                                EmployeeId = Convert.ToInt32(e.Id),
                                MeetingId = Convert.ToInt32(meeting.Id),
                                Attended = Convert.ToInt16(e.Attended),
                                MissingReason = e.MissingReason,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };
                            _context.EmployeeMeeting.Add(em);
                        }
                        _context.SaveChanges();

                        foreach (Employees e in attendance.Guests)
                        {
                            var em = new EmployeeMeeting
                            {
                                EmployeeId = Convert.ToInt32(e.Id),
                                MeetingId = Convert.ToInt32(meeting.Id),
                                Attended = 1,
                                MissingReason = "Asistió",
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };
                            _context.EmployeeMeeting.Add(em);
                        }
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest(new { message = ex.Message });
                    }
                }
            } 
            else
            {
                return StatusCode(500);
            }


            return Ok();
        }

        private bool MeetingsExists(long id)
        {
            return _context.Meetings.Any(e => e.Id == id);
        }
    }
}
