using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UNBK_Client.Models
{
    public class ExamModel
    {
        public soal soal { get; set; }
        public paket_soal paket_soal { get; set; }
        public jawaban jawaban { get; set; }
        public jadwal jadwal { get; set; }  

    }


    public class TokenModel
    {
        public jadwal jadwal { get; set; }
    }

}