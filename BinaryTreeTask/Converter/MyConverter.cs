﻿using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System.Collections.Generic;

namespace BinaryTree.Converter
{
    public static class MyConverter
    {
        public static void ConvertBinaryTreeToList<T>(TreeNode<T> root, List<T> students) where T : Student
        {
            if(root == null)
            {
                return;
            }

            students.Add(root.Data);
            ConvertBinaryTreeToList(root.LeftNode, students);
            ConvertBinaryTreeToList(root.RightNode, students);
        }
    }
}