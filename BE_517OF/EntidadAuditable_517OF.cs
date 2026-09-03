namespace BE_517OF
{
    public abstract class EntidadAuditable_517OF : EntidadBase_517OF
    {
        public DateTime FechaCreacion_517OF { get; set; }
        public DateTime? FechaEliminacion_517OF { get; set; }
        public string DVH_517OF { get; set; } = string.Empty;
    }
}
