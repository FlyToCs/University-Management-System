namespace University_Management_System.Domain.Entities;

public class ClassSchedule
{
    public DayOfWeek Day { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public ClassSchedule(DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time");

        Day = day;
        StartTime = startTime;
        EndTime = endTime;
    }

    public bool ConflictsWith(ClassSchedule other)
    {
        return Day == other.Day &&
               StartTime < other.EndTime &&
               EndTime > other.StartTime;
    }
}