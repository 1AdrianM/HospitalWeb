using Proyecto_Hospital.Models;

namespace Proyecto_Hospital.Helpers
{
    public static class Departments
    {
        public static List<Appointment>GetAll()
        {
           return new List<Appointment>
            {
         new  Appointment { ValueAPt = 1, Apartment = "Neurologia" },
        new  Appointment  { ValueAPt = 2, Apartment = "Cardiologia" },
        new  Appointment   { ValueAPt = 3, Apartment = "Pediatria" },
        new  Appointment     { ValueAPt = 3, Apartment = "Gastroenterologia" },
        new  Appointment   { ValueAPt = 4, Apartment = "Dermatologia" },
        new  Appointment     { ValueAPt = 5, Apartment = "Oncologia" },
        new  Appointment      { ValueAPt = 6, Apartment = "Otolaryngologia"},
        new  Appointment  { ValueAPt = 7, Apartment = "Urologia" }

            };

        }
    }
}
