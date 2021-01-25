using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation_V2.Shared
{
    public class FactureDTO
    {
        [Required(ErrorMessage = "Le nom du client est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom est trop long (50 char. max).")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Le numéro est obligatoire.")]
        [StringLength(15, ErrorMessage = "Le numéro est trop long (15 char. max).")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "La date d'émission est obligatoire.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DateEmission { get; set; } = DateTime.Now;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DateReglement { get; set; }

        [Required(ErrorMessage = "Le montant dû est obligatoire.")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Le montant dû ne peut pas être négatif.")]
        public decimal MontantDu { get; set; }
        
        [Required(ErrorMessage = "Le montant dû est obligatoire.")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Le montant réglé ne peut pas être négatif.")]
        public decimal MontantRegle { get; set; }
        public FactureDTO() { }

        public Facture ToFacture()
        {
            return new Facture
            {
                Client = this.Client,
                Numero = this.Numero,
                DateEmission = this.DateEmission,
                DateReglement = this.DateReglement,
                MontantDu = this.MontantDu,
                MontantRegle = this.MontantRegle,
                ResteARecevoir = this.MontantDu - this.MontantRegle,
            };
        }
    }
}
