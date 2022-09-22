using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarouselImagesApp.Models
{
    public class CarouselSliders
    {
        [Key]
        public int CarouselId { get; set; }

        [DisplayName("Título")]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Nombre de la imagen")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Sube una foto")]
        public IFormFile ImageFile { get; set; }
    }
}
