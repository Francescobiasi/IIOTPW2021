﻿using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Lesson_services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ICourseRepository _courseRepository;

        public LessonService(ILessonRepository lessonService, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, IClassroomRepository classroomRepository, ICourseRepository courseRepository)
        {
            _lessonRepository = lessonService;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _classroomRepository = classroomRepository;
            _courseRepository = courseRepository;
        }

        public async Task AddNewLesson(LessonInfo lessonInfo)
        {
            var lesson = lessonInfo.ToLesson();
            lesson.Course = await _courseRepository.GetCourseById(lessonInfo.CourseId);
            lesson.Classroom = await _classroomRepository.GetClassroomById(lessonInfo.ClassroomId);
            lesson.Subject = await _subjectRepository.GetSubjectById(lessonInfo.SubjectId);
            lesson.Teacher = await _teacherRepository.GetTeacherById(lessonInfo.TeacherId);
            await _lessonRepository.InsertLesson(lesson);
        }
    }
}