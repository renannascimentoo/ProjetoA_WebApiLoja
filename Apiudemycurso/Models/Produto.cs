using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiudemycurso.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="O nome é Obrigatório")]
        [StringLength(20,ErrorMessage ="Deve ter entre 20 e 5 caracteres.",MinimumLength = 5)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="A Descrição deve ter no máximo {1} caracteres")]
        public string? Descricao { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage ="O Preço deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300,MinimumLength = 10)]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
    }
}
