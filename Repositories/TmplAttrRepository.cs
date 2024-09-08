using ItemCatalogAPI.Data;
using ItemCatalogAPI.Interface;
using ItemCatalogAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;

namespace ItemCatalogAPI.Repositories
{
    public class TmplAttrRepository : ITmplAttrRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TmplAttrRepository> _logger;

        public TmplAttrRepository(ApplicationDbContext context, ILogger<TmplAttrRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<TmplAttrs>> GetAllTmplAttrAsync()
        {
            return await _context.tmpl_attrs.ToListAsync();
        }

    
        public static AttrVal ParseAttrVal(string json)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (data == null)
            {
                throw new ArgumentException("Invalid JSON format");
            }

            var idField = data.ContainsKey("id") ? data["id"] : string.Empty;
            var idParts = idField.Split(',').Select(part => part.Split(':')).ToDictionary(pair => pair[0], pair => pair.Length > 1 ? pair[1] : string.Empty);

            var attrVal = new AttrVal
            {
                Id = idField,
                Price = idParts.GetValueOrDefault("Price"),
                Answer = idParts.GetValueOrDefault("Answer"),
                Type = idParts.GetValueOrDefault("Type"),
                Code = idParts.GetValueOrDefault("Code"),
                SerNum = idParts.GetValueOrDefault("SerNum"),
                Notes = idParts.GetValueOrDefault("Notes"),
                Title = data.GetValueOrDefault("title"),
                Description = data.GetValueOrDefault("description")
            };

            return attrVal;
        }

        public async Task<List<AttrVal>> GetAttributeValueAsync(string parMessageId)
        {
            var tmplAttr = await _context.tmpl_attrs
                .Where(attr => attr.PAR_MESSAGE_ID == parMessageId)
                .Select(attr => attr.ATTR_VAL)
                .ToListAsync();

            var attributeValues = new List<AttrVal>();

            foreach (var json in tmplAttr)
            {
                try
                {
                    var attrVal = ParseAttrVal(json);
                    if (attrVal != null)
                    {
                        attributeValues.Add(attrVal);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing JSON: {ex.Message}");
                }
            }

            return attributeValues;
        }

    }
}
