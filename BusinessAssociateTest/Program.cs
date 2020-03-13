using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessAssociate.API.BusinessAssociate;
using BusinessAssociate.API.DTOs;
using EGMS.BusinessAssociate.Domain;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAssociateConsoleTest
{
    class Program
    {
        private static readonly EGMSAssociateRepository Repository = new EGMSAssociateRepository();

        static void Main()
        {
            //internalAssociateController.PutAssociate();

            InternalAssociate atlantaGasLight = AddInternalAssociate(123456789, "AtlantaGasLight", "AGL");
            ExternalAssociate transco = AddExternalAssociate(123456790, "Transco", "TRX");

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an Operating Context to an internal business associate for a particular LDC
            atlantaGasLight.AddOperatingContext();

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an External BA Operating Context to an external business associate for a
            //      particular LDC, set the Provider Type to Marketer and generate a new Third-Party Supplier Id for the new operating context.
            transco.AddOperatingContext(new ExternalOperatingContext(ProviderType.MARKETER));

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an External BA Operating Context to an external business associate for a
            //      particular LDC, set the Provider Type to Pooler and generate a new Third-Party Supplier Id for the new operating context.
            transco.AddOperatingContext(new ExternalOperatingContext(ProviderType.POOLER));

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an External BA Operating Context to an external business associate for a
            //      particular LDC, set the Provider Type to Shipper and generate a new Third-Party Supplier Id for the new operating context.
            transco.AddOperatingContext(new ExternalOperatingContext(ProviderType.SHIPPER));

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an External BA Operating Context to an external business associate for a
            //      particular LDC, set the Provider Type to Supplier and generate a new Third-Party Supplier Id for the new operating context.
            transco.AddOperatingContext(new ExternalOperatingContext(ProviderType.SUPPLIER));

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add an External BA Operating Context to an external business associate for a
            //      particular LDC, set the Provider Type to Asset Manager and generate a new Third-Party Supplier Id for the new operating context.
            transco.AddOperatingContext(new ExternalOperatingContext(ProviderType.ASSET_MANAGER));

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Update the status of an External BA Operating Context for an external business associate from Pending to Active
            transco.OperatingContexts[0].Status = Status.ACTIVE;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add a new Agent Relationship for two external business associates
            // TO DO:  Add Start Date, End Date

            DUNSNumber transcoAgentsDUNSNumber = DUNSNumber.Create(123456791).Value;
            LongName longName = LongName.Create("TranscoAgents").Value;
            ShortName shortName = ShortName.Create("TRXA").Value;

            Agent transcoAgents = new Agent(transcoAgentsDUNSNumber,
                longName, shortName, ExternalAssociateType.SELF_PROVIDER)
            {
                OperatingContexts = new List<OperatingContext> { new ExternalOperatingContext() }
            };

            AgentRelationship agentRelationship = new AgentRelationship(transco, transcoAgents);
            transco.AddAgentRelationship(agentRelationship);

            Role roleA = new Role();

            UserOperatingContext userOperatingContextA = new UserOperatingContext {Role = roleA};
            agentRelationship.AgentUserList.Add(userOperatingContextA);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Terminate an existing Agent Relationship for two external business associates
            // The specs call for setting the end date, but we have instead added an active flag.
            agentRelationship.IsActive = false;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Modify an existing Agent Relationship for two external business associates by adding a
            //   new user to the relationship, modifying the role of a user within a relationship or
            //   remove a user from the relationship.
            UserOperatingContext userOperatingContextB = new UserOperatingContext();
            agentRelationship.AgentUserList.Add(userOperatingContextB);

            Role roleB = new Role();
            userOperatingContextB.Role = roleB;
            agentRelationship.AgentUserList.Remove(userOperatingContextB);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Add a new Asset Manager Relationship for an external business associate and an internal business associate
            AssetManagerRelationship assetManagerRelationship =
                new AssetManagerRelationship(atlantaGasLight, transcoAgents);
            transco.AgentRelationships.Add(agentRelationship);

            assetManagerRelationship.AssetManagerUserList.Add(userOperatingContextA);
            atlantaGasLight.AssetManagerRelationships.Add(assetManagerRelationship);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Modify an existing Asset Manager Relationship by adding a new user
            //   to the relationship, modifying the role of a user within a relationship
            //   or remove a user from the relationship.
            assetManagerRelationship.AssetManagerUserList.Add(userOperatingContextB);
            userOperatingContextB.Role = roleB;
            assetManagerRelationship.AssetManagerUserList.Remove(userOperatingContextA);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // JOEF:  Assuming that this is not a legitimate use case until we get clarification
            // Designate an external business associate as a shipper for a particular market
        }

        #region Controller Method Wrappers

        private static InternalAssociate AddInternalAssociate(int dunsNumber, string longName, string shortName)
        {
            return new InternalAssociate();

            //Console.WriteLine("Adding InternalAssociate " + longName);

            //InternalAssociateController controller = new InternalAssociateController();

            //CreateInternalAssociateDto dto = new CreateInternalAssociateDto(dunsNumber, longName, shortName,
            //    InternalAssociateType.LDC_FACILITY);

            //return FetchFromTaskActionResult(controller.Create(dto));
        }

        private static ExternalAssociate AddExternalAssociate(int dunsNumber, string longName, string shortName)
        {
            Console.WriteLine("Adding ExternalAssociate " + longName);

            ExternalAssociateController controller = new ExternalAssociateController(Repository);

            CreateExternalAssociateDto dto = new CreateExternalAssociateDto(dunsNumber, longName, shortName,
                ExternalAssociateType.REGULATED_UTILITY_PROVIDER);

            return FetchFromTaskActionResult(controller.Create(dto));
        }

        #endregion


        #region Controller Helpers

        public static T FetchFromTaskActionResult<T>(Task<ActionResult<T>> taskActionResult)
        {
            return (T)((CreatedAtActionResult)taskActionResult.Result.Result).Value;
        }

        #endregion
    }
}
