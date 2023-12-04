using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Models;
public class GuestAppSettings
{
    public const string SecionName = "AppSettings";
    public string GaleryPathUrl { get; set; }
    public bool DisplayGaleryPage { get; set; }
}
