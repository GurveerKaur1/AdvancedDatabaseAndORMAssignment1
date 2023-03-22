using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvancedDatabaseAndORMAssignment1.Models.ViewModel
{
    public class AddToListenerListVM
    {
        public HashSet<SelectListItem> Listeners { get; set; } = new HashSet<SelectListItem>();

        public int? PodcastId { get; set; }
        public int?  ListenerListId { get; set; }
        public string? ViewMessage { get; set; }

        public void PopulateLists(IEnumerable<ListenerLists> listenerLists)
        {

            foreach (ListenerLists p in listenerLists)
            {
                Listeners.Add(new SelectListItem($"{p.Name}", p.Id.ToString()));
            }

        }
        public AddToListenerListVM(IEnumerable<ListenerLists> listenerLists, int Id)
        {
            PopulateLists(listenerLists);
            PodcastId = Id;
        }


        public AddToListenerListVM()
        {

        }

    }
}
