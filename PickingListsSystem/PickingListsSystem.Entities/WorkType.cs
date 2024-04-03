namespace PickingListsSystem.Entities
{
    public class WorkType
    {
        public int Id { get; set; }

        public int? TypeOfWork { get; set; } 

        public string? WorkTypeTranscript { get; set; }

        public ICollection<Work> Works { get; set; }

        public ICollection<Project> Project { get; set; }

    }
}
