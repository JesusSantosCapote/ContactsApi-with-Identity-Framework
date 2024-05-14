namespace BusinessLogic.DTO
{
    public class ContactDetailDto: ContactDto
    {
        public Guid Id { get; set; }

        public int Age
        {
            get
            {
                DateTime currentDate = DateTime.Now;

                if (currentDate.Day >= DateOfBirth.Day && currentDate.Month >= DateOfBirth.Month)
                {
                    return currentDate.Year - DateOfBirth.Year;
                }
                else return currentDate.Year - DateOfBirth.Year - 1;
            }
        }
    }
}
