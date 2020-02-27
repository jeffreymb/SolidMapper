using System;

namespace SolidMapper
{
    public struct MappingTree : IMappingTree
    {
        public object[] Items { get; }
        public object Parent => Items.Length < 2 ? null : Items[^2];

        public MappingTree(IMappingTree tree,
                           object newItem)
        {
            if (tree != null)
            {
                var newTree = new object[tree.Items.Length + 1];
                Array.Copy(tree.Items, 0, newTree, 0, tree.Items.Length);
                newTree[^1] = newItem;
                Items = newTree;
            }

            else
            {
                Items = new object[1] { newItem };
            }
        }
    }
}
