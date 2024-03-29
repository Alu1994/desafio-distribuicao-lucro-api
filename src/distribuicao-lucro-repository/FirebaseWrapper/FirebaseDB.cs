﻿using System;
using System.Net.Http;

namespace DistribuicaoLucro.Repository.FirebaseWrapper
{
    public class FirebaseDB
    {
        public FirebaseDB(string baseURL)
        {
            this.RootNode = baseURL;
        }

        private string RootNode { get; set; }

        public FirebaseDB Node(string node)
        {
            if (node.Contains("/"))
            {
                throw new FormatException("Node não pode ter '/', use o NodePath.");
            }

            return new FirebaseDB($"{this.RootNode}/{node}");
        }

        public FirebaseDB NodePath(string nodePath)
        {
            return new FirebaseDB($"{this.RootNode}/{nodePath}");
        }

        public FirebaseResponse Get()
        {
            return new FirebaseRequest(HttpMethod.Get, this.RootNode).Execute();
        }

        public override string ToString()
        {
            return this.RootNode;
        }
    }
}