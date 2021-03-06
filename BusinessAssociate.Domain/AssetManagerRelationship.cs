﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class AssetManagerRelationship
    {
        public AssetManagerRelationship(InternalAssociate principal, ExternalAssociate assetManager) : this()
        {
            Principal = principal;
            AssetManager = assetManager;
        }

        public AssetManagerRelationship()
        {
            AssetManagerUserList = new List<UserOperatingContext>();
        }

        [Key]
        public long Id { get; set; }

        public InternalAssociate Principal { get; set; }
        public ExternalAssociate AssetManager { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<UserOperatingContext> AssetManagerUserList { get; set; }
    }
}