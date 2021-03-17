using EFDAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EFDAL
{
    public class PowerRangerDal
    {
        public PowerRangerDal()
        {
            using (DB_Context dB_Context = new DB_Context()) { dB_Context.Database.Initialize(true); }
        }

        public IEnumerable<Lecturer> GetAllLecturers()
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                return dB_Context.Lecturers.Include("Lectures").ToList();
            }
        }

        public IEnumerable<Lecture> GetAllLectures()
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                return dB_Context.Lectures.Include("Lecturer").ToList();
            }
        }

        public IEnumerable<Lecture> GetLecturesByLecturerName(string PartialLecturerName)
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                return dB_Context.Lectures.Include("Lecturer").Where(l => l.Lecturer.Name.StartsWith(PartialLecturerName)).ToArray();
            }
        }

        public IEnumerable<Lecture> GetLecturesByLectureName(string PartialLectureName)
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                return dB_Context.Lectures.Include("Lecturer").Where(l => l.Name.StartsWith(PartialLectureName)).ToArray();
            }
        }

        public IEnumerable<Lecture> GetLecturesByDate(DateTime? selectedDate)
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                return dB_Context.Lectures.Include("Lecturer").Where(l => l.Date == selectedDate).ToArray();
            }
        }

        public void Delete(int id)
        {
            using (DB_Context dB_Context = new DB_Context())
            {
                var lecturer = dB_Context.Lecturers.FirstOrDefault(l => l.ID == id);

                if (lecturer != null)
                {
                    dB_Context.Lecturers.Remove(lecturer);
                    dB_Context.SaveChanges();
                }
            }
        }
    }
}
