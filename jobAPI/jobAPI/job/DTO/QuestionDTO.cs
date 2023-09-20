﻿using job.Models;

namespace job.DTO
{
    public class QuestionDTO
    {
        public int examsId { get; set; }
        public string question { get; set; }
        public string correctAnswer { get; set; } //1 2 3 4
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public float questionDegree { get; set; }
    }
}
