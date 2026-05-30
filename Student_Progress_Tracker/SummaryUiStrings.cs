using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class SummaryUiStrings
    {
        public string Title { get; set; } = "ПІДСУМКОВА ВІДОМІСТЬ";
        public string HeaderNo { get; set; } = "№";
        public string HeaderName { get; set; } = "ПІБ Студента";
        public string HeaderLectures { get; set; } = "Лекції";
        public string HeaderLabs { get; set; } = "Лаби";
        public string HeaderPoints { get; set; } = "Бали";
        public string HeaderStatus { get; set; } = "Статус";
        public string EmptyMessage { get; set; } = "Журнал порожній.";
        public string StatusAdmitted { get; set; } = "ДОПУЩЕНИЙ";
        public string StatusNotAdmitted { get; set; } = "НЕ ДОПУЩЕНИЙ";
        public string FooterMessage { get; set; } = "Натисніть клавішу...";
    }
}