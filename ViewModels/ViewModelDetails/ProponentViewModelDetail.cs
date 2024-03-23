namespace famiCCV1.Server.ViewModels.ViewModelDetails
{
    public class ProponentViewModelDetail
    {
        public int Id { get; set; }
        public string NProponent { get; set; }
        public string Trajectory { get; set; }
        public int FkRepresentativeId { get; set; }
        public int FkTproponentId { get; set; }
        public RepresentativeViewModelDetail Representative { get; set; }
        public ProponentTypeViewModel ProponentType { get; set; }

        public ProposedValueViewModel ProposedValue { get; set; }
    }

}
