namespace TerceiroCore.Models.Dados
{
    public class AcoesMedia
    {
        public double CalcularMedia(ModelMedia media)
        {
            return (double.Parse(media.Jan) + double.Parse(media.Fer) + double.Parse(media.Mar) + double.Parse(media.Abr)) / 4;
        }
        public double CalcularSoma(ModelMedia media)
        {
            return (double.Parse(media.Jan) + double.Parse(media.Fer) + double.Parse(media.Mar) + double.Parse(media.Abr));
        }

    }
}
