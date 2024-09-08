using ItemCatalogAPI.Models;

namespace ItemCatalogAPI.Interface
{
    public interface ITmplAttrRepository
    {
        Task<List<TmplAttrs>> GetAllTmplAttrAsync();

        Task<List<AttrVal>> GetAttributeValueAsync(string parMessageId);

      
    }
}
