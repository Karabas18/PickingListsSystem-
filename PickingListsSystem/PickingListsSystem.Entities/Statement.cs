namespace PickingListsSystem.Entities
{
    public class Statement
    {
        public int Id { get; set; }

        public string? StatementStatus { get; set; }

        public DateTime? StatementDate { get; set; }

        public ICollection<Project> Project { get; set; }
        //добавить для создания и с материалами и с работами. Добавить словарь для создания 1 ведомости
        // для нескольких одинаковых сущностей (материалов, работ, или проектов)
        public ICollection<Material> Materials { get; set; }
    }
}
