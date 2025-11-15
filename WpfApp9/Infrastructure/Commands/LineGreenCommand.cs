using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp9.Infrastructure.Commands.BaseCommand;
using WpfApp9.Services;

namespace WpfApp9.Infrastructure.Commands
{
    internal class LineGreenCommand : Command
    {
        public override bool CanExecute(object? parametr) => true;

        public override void Execute(object? command)
        {
            GradientGenerate.GetGreenGradientBrush();
        }

    }
}
