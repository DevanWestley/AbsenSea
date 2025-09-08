using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsenSea
{
    public enum CrewStatus
    {
        Present,
        Absent,
        Unknown
    }

    public enum EquipmentCondition
    {
        Good,
        Damaged,
        Missing
    }

    public enum VerificationResult
    {
        Verified,
        NotVerified
    }

    public class CrewMember
    {
        public string CrewID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public List<SafetyEquipment> AssignedEquipment { get; set; }
        public CrewStatus Status { get; set; }

        public CrewMember()
        {
            AssignedEquipment = new List<SafetyEquipment>();
            Status = CrewStatus.Unknown;
        }

        public void CheckIn()
        {
            Status = CrewStatus.Present;
            Console.WriteLine($"{Name} checked in.");
        }

        public void CheckOut()
        {
            Status = CrewStatus.Absent;
            Console.WriteLine($"{Name} checked out.");
        }
    }

    public class SafetyEquipment
    {
        public string EquipmentID { get; set; }
        public string Type { get; set; }
        public EquipmentCondition Condition { get; set; }

        public void AssignToCrew(CrewMember crew)
        {
            crew.AssignedEquipment.Add(this);
            Console.WriteLine($"{Type} assigned to {crew.Name}.");
        }

        public void UpdateCondition(EquipmentCondition newCondition)
        {
            Condition = newCondition;
            Console.WriteLine($"{Type} condition updated to {Condition}.");
        }
    }

    public class VisionSystem
    {
        public string CameraID { get; set; }
        public string Location { get; set; }

        public void CaptureFrame()
        {
            Console.WriteLine("Frame captured.");
        }

        public void DetectEquipment()
        {
            Console.WriteLine("Equipment detected.");
        }

        public void DetectCrew()
        {
            Console.WriteLine("Crew detected.");
        }
    }

    public class AttendanceRecord
    {
        public string RecordID { get; set; }
        public CrewMember CrewMember { get; set; }
        public CrewStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public VerificationResult VerifiedBy { get; set; }

        public void MarkAbsent()
        {
            Status = CrewStatus.Absent;
            Console.WriteLine($"Record {RecordID}: {CrewMember.Name} marked absent.");
        }

        public void MarkPresent()
        {
            Status = CrewStatus.Present;
            Console.WriteLine($"Record {RecordID}: {CrewMember.Name} marked present.");
        }
    }

    public class AttendanceManager
    {
        public List<AttendanceRecord> Records { get; set; }

        public AttendanceManager()
        {
            Records = new List<AttendanceRecord>();
        }

        public void AddRecord(AttendanceRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Attendance record {record.RecordID} added.");
        }

        public List<CrewMember> GetAbsentees()
        {
            List<CrewMember> absentees = new List<CrewMember>();
            foreach (var record in Records)
            {
                if (record.Status == CrewStatus.Absent)
                    absentees.Add(record.CrewMember);
            }
            return absentees;
        }

        public void GenerateReport()
        {
            Console.WriteLine("Attendance Report:");
            foreach (var record in Records)
            {
                Console.WriteLine($"{record.CrewMember.Name} - {record.Status} at {record.DateTime}");
            }
        }
    }
}
