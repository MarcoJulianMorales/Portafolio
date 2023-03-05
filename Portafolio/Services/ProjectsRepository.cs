using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IProjectsRepository
    {
        List<ProjectDTO> getProjects();
    }
    public class ProjectsRepository: IProjectsRepository
    {
        public List<ProjectDTO> getProjects()
        {
            return new List<ProjectDTO> {
                new ProjectDTO(){
                    tittle = "Amazon",
                    description = "Worked as courier",
                    link ="https://www.amazon.com",
                    URLimg="/img/amazon.png"

                },
                new ProjectDTO(){
                    tittle = "facebook",
                    description = "React news changes",
                    link ="https://www.facebook.com",
                    URLimg="/img/facebook.png"

                },
                new ProjectDTO(){
                    tittle = "Reddit",
                    description = "Social network",
                    link ="https://www.reddit.com",
                    URLimg="/img/reddit.png"

                },
                new ProjectDTO(){
                    tittle = "Steam",
                    description = "Online gaming store",
                    link ="https://www.store.steampowered.com",
                    URLimg="/img/steam.png"

                },
            };
        }
    }
}
