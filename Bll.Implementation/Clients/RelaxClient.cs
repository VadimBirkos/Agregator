﻿using System;
using System.Collections.Generic;
using Bll.Implementation.Parsers;
using Bll.Interface;
using Dal.Interface;

namespace Bll.Implementation.Clients
{
    public class RelaxClient :IClient
    {
        private readonly IParser _parser;

        public RelaxClient()
        {
            _parser = new RelaxParser();
        }

        public RelaxClient(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<PartyModel> GetParties(string url)
        {            
            return _parser.Parse(url);
        }
    }
}
