namespace DAL_517OF
{
    public interface IAbmcDal_517OF<TEntidad>
    {
        int Alta_517OF(TEntidad entidad);
        int Baja_517OF(TEntidad entidad);
        int Modificar_517OF(TEntidad entidad);
        List<TEntidad> Consultar_517OF();
    }
}
