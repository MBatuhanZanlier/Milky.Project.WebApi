﻿namespace MilkyProject.WebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
