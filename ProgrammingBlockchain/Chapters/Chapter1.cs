﻿using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingBlockchain.Chapters
{
    class Chapter1
    {
        static Network network = Network.TestNet;
        public Script Lesson1(BitcoinSecret secret = null)
        {
            Key key = secret == null ? new Key() : secret.PrivateKey; //generates a new private key.
            PubKey pubKey = key.PubKey; //gets the matching public key.
            Console.WriteLine("Public Key: {0}", pubKey);
            KeyId hash = pubKey.Hash; //gets a hash of the public key.
            Console.WriteLine("Hashed public key: {0}", hash);
            secret = secret ?? key.GetBitcoinSecret(network);
            Console.WriteLine("Bitcoin Secret: {0}", secret);
            BitcoinPubKeyAddress address = pubKey.GetAddress(network); //retrieves the bitcoin address.
            Console.WriteLine("Address: {0}", address);
            Script scriptPubKeyFromAddress = address.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from address: {0}", scriptPubKeyFromAddress);
            Script scriptPubKeyFromHash = hash.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from hash: {0}", scriptPubKeyFromHash);
            return scriptPubKeyFromAddress;
        }

        public void Lesson2(Script scriptPubKey)
        {        
            BitcoinAddress address = scriptPubKey.GetDestinationAddress(network);
            Console.WriteLine("Bitcoin Address: {0}", address);
        }

        public void Lesson3(Script scriptPubKey)
        {            
            KeyId hash = (KeyId)scriptPubKey.GetDestination();
            Console.WriteLine("Public Key Hash: {0}", hash);
            BitcoinAddress address = new BitcoinPubKeyAddress(hash, network);
            Console.WriteLine("Bitcoin Address: {0}", address);
        }

        public void Lesson4()
        {
            Key key = new Key();
            BitcoinSecret secret = key.GetBitcoinSecret(network);
            Console.WriteLine("Bitcoin Secret: {0}", secret);
        }

    }
}
