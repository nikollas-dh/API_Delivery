using System;
using System.Collections.Generic;

namespace API_Delivery.Models;

public partial class FraseSecretum
{
    public int IdFrase { get; set; }

    public string Frase { get; set; } = null!;

    public virtual ICollection<RecuperarSenha> RecuperarSenhas { get; set; } = new List<RecuperarSenha>();
}
