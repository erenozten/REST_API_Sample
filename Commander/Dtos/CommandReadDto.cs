namespace Commander.Dtos{
    public class CommandReadDto{
    // [Key]
    public int Id { get; set; }

    // [Required]
    // [MaxLength(250)]
    public string HowTo { get; set; }

    // [Required]
    // [MaxLength(250)]    
    public string Line { get; set; }
    
    // [Required]
    // [MaxLength(250)]
    // Platform property'sini dışarıya açmak istemiyoruz.
    // O yüzden dto'muza dahil etmeyeceğiz.
    // public string Platform { get; set; }
    }
}