using PvcCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvcPlugins
{
    public class PvcAngularPreMinifier : PvcPlugin
    {
        public override string[] SupportedTags
        {
            get
            {
                return new[] { ".js" };
            }
        }
        public PvcAngularPreMinifier()
        {
            // Plugin setup
        }

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var outputStreams = new List<PvcStream>();
            foreach (var inputStream in inputStreams)
            {
                var jsContent = PvcUtil.StreamToTempFile(inputStream);
                var cssContent = new AngularPreMinifier(jsContent).Parse();

                var newStreamName = Path.Combine(Path.GetDirectoryName(inputStream.StreamName), Path.GetFileNameWithoutExtension(inputStream.StreamName) + ".css");
                var resultStream = PvcUtil.StringToStream(cssContent, newStreamName);

                outputStreams.Add(resultStream);

            };
            return outputStreams;
        }
    }
}
