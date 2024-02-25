using LeadManagementApi.Utils;
using Newtonsoft.Json;

namespace LeadManagementApi.Models.Enums;

[JsonConverter(typeof(EnumConverter))]
public enum LeadStage
{
  INITIAL,
  CREATED,
  PROSPECTING,
  QUALIFICATION,
  PROPOSAL,
  NEGOTIATION,
  CLOSED
}