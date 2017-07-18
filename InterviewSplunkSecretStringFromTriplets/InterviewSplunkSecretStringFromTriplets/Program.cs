using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSplunkSecretStringFromTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetSecretStringFromTriplets(new List<string>() { "fea", "dec", "ebc", "eba", "fda", "bac"});
        }

        public class DagNode
        {
            public char value;
            public List<DagNode> childs = new List<DagNode>();
        }
        public static string GetSecretStringFromTriplets(List<string> triplets)
        {
            var nodes = new Dictionary<char, DagNode>();
            var roots = new HashSet<DagNode>();
            foreach (var s in triplets)
            {
                DagNode prev = null;
                DagNode grampa = null;
                DagNode parent = null;
                for (int i = 0; i < s.Length; ++i)
                {
                    DagNode node = null;
                    if (!nodes.TryGetValue(s[i], out node))
                    {
                        node = new DagNode() { value = s[i] };
                        if (prev != null)
                        {
                            prev.childs.Add(node);
                        }
                        else
                        {
                            roots.Add(node);
                        }
                        nodes.Add(s[i], node);
                    }
                    else
                    {
                        if (i == 2)
                        {
                            RemoveChildIfCanReach(grampa, node, parent);
                        }
                        if (prev != null && !CanReach(prev, node, null))
                        {
                            prev.childs.Add(node);
                        }
                    }

                    if (i == 0) grampa = node;
                    else if (i == 1) parent = node;
                    prev = node;
                }
                roots.Remove(parent);
                roots.Remove(prev);
            }
            var resp = new StringBuilder();
            GetStringFromDag(roots.FirstOrDefault(), resp);
            return resp.ToString();
        }

        public static void RemoveChildIfCanReach(DagNode root, DagNode target, DagNode notUsing)
        {
            var toRemove = new List<DagNode>();
            foreach (var node in root.childs)
            {
                if (CanReach(node, target, notUsing))
                {
                    toRemove.Add(node);
                }
            }
            foreach (var tr in toRemove)
            {
                root.childs.Remove(tr);
            }
        }

        public static bool CanReach(DagNode from, DagNode target, DagNode notUsing)
        {
            if (from == notUsing) return false;
            if (from == target) return true;
            foreach (var node in from.childs)
            {
                if (CanReach(node, target, notUsing)) return true;
            }
            return false;
        }
        public static void GetStringFromDag(DagNode n, StringBuilder sb)
        {
            sb.Append(n.value);
            if (n.childs.Count == 0) return;
            GetStringFromDag(n.childs.FirstOrDefault(), sb);
        }
    }
}
