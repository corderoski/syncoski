using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGExplorer.Framework.Entities;

namespace Syncoski.Framework
{
    public class SyncerComparer
    {

        public void Compare(NodeString origin, NodeString objB)
        {
            var diff = new Collection<String>();

            if (!origin.ToString().Equals(objB.ToString()))
                diff.Add("base != base");

            var test1 = origin.Childs == objB.Childs;
            var test2 = Equals(origin.Childs, objB.Childs);

            var test3 = origin.Equals(objB);

            //  if diff between counts
            if (origin.Childs.Count != objB.Childs.Count)
            {
                for (var i = 0; i < origin.Childs.Count; i++)
                {
                    if (origin.Childs.ElementAt(i) != objB.Childs.ElementAt(i))
                        diff.Add(String.Format("{0} != {1}", origin.Childs.ElementAt(i), objB.Childs.ElementAt(i)));
                }
            }
                
            //this.Childs.All(a => external.Childs.Any(b => a == b));

            var aux = origin.Childs.All(a => objB.Childs.Any(a.Equals));

        }

    }

    public struct SyncComparerResult
    {
        public Int32 Count;
        public IEnumerable<String> Differences;
    }


}
