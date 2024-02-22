using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LeadManagementApi.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
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