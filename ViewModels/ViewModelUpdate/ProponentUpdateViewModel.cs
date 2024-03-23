namespace famiCCV1.Server.ViewModels.ViewModelUpdate
{
    public class ProponentUpdateViewModel
    {
        public int Id { get; set; } // Agrega la propiedad Id para identificar el proponente
        public string NProponent { get; set; }
        public string Trajectory { get; set; }
        public RepresentativeUpdateViewModel Representative { get; set; }
        public ProponentTypeUpdateViewModel ProponentType { get; set; }
        public int FkProponentId { get; set; } // Agrega la propiedad FkProponentId
    }
}
