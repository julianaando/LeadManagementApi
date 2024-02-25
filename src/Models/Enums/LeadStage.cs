using System.Runtime.Serialization;
using LeadManagementApi.Utils;
using Newtonsoft.Json;

namespace LeadManagementApi.Models.Enums;

public enum LeadStage
{
  [EnumMember(Value = "INITIAL")]
  INITIAL,
  [EnumMember(Value = "CREATED")]
  CREATED,
  [EnumMember(Value = "PROSPECTING")]
  PROSPECTING,
  [EnumMember(Value = "QUALIFICATION")]
  QUALIFICATION,
  [EnumMember(Value = "PROPOSAL")]
  PROPOSAL,
  [EnumMember(Value = "NEGOTIATION")]
  NEGOTIATION,
  [EnumMember(Value = "CLOSED")]
  CLOSED
}