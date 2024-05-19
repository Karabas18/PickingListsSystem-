namespace PickingListsSystem.Entities
{
    public class Material
    {
        public int Id { get; set; }

        public int? MaterialMark { get; set; }

        public string? MaterialName { get; set; }

        public string? MaterialUnit { get; set; }

        public string? MaterialGost { get; set; }

        public int? MaterialRB { get; set; }

        public int? MaterialRL { get; set; }

        public int? MaterialRH { get; set; }

        public double? MaterialV { get; set; }

        public int? MaterialWeight { get; set; }

        public int? MaterialType { get; set; }

        public ICollection<Work> Work { get; set; } = new List<Work>();

        //public Statement Statement { get; set; } // добавлена связь

        //public int? StatementId { get; set; } // добавлена связь

        //public ICollection<Statement> Statement { get; set; } = new List<Statement>();
    }
}
