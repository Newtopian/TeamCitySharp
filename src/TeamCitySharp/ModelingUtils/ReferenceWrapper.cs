using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ModelingUtils
{
    public class ReferenceWrapper<TDomainEntityType>
    {
        public string Href { get; set; }
        internal ITeamCityCaller _caller { get; set; }
        private TDomainEntityType _domainObject { get; set; }

        public TDomainEntityType Fetch {
            get
            {
                if (_caller != null && _domainObject == null)
                {
                    _domainObject = _caller.GetHRef<TDomainEntityType>(Href);
                }
                return _domainObject;
            }
        }
    }
}
