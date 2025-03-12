namespace Models;
public class Animal{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Classification { get; set; }
    public string Sex { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfZooEntry { get; set; }
    public DateTime? DateOfZooLeaving { get; set; }
    public DateTime? DateOfPassing { get; set; }
    public string? EnclosureName {get;set;}
    public Animal() {}
    public Animal(Enclosure enclosure) {
        EnclosureName = enclosure.Name;
    }
}