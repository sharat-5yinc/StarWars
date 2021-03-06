﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EpisodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Episode> AddEpisode(Episode episode)
        {
            _appDbContext.Episodes.Add(episode);
            _appDbContext.SaveChanges();
            return await Task.FromResult(episode);
        }
        public async Task<Episode> UpdateEpisode(int episodeId, Episode episode)
        {
            if (episode.Id == 0 && episodeId != 0)
                episode.Id = episodeId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Episodes.Attach(episode).Property(p => p.EpisodeName).IsModified = true;
            _appDbContext.SaveChanges();
            return await Task.FromResult(episode);
        }
        public async Task<Episode> Associate_Character_With_Episode(int episodeId, int characterID)
        {
            var episode = _appDbContext.Episodes.Include(e=>e.Cast).FirstOrDefault(f => f.Id == episodeId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterID);
            var episodeCharacter = new EpisodeCharacter
            {
                EpisodeId = episodeId,
                CharacterId = characterID,
                Episode = episode,
                Character = character
            };
            var charactesExists = episode.Cast.FirstOrDefault(c => c.CharacterId == characterID && c.EpisodeId == episodeId);
            if (charactesExists == null) {
                episode.Cast.Add(episodeCharacter);
                _appDbContext.SaveChanges();
            }            
            return await Task.FromResult(episode);
        }

        public async Task<Episode> Remove_Character_From_Episode(int episodeId, int characterID)
        {
            var episode = _appDbContext.Episodes.FirstOrDefault(f => f.Id == episodeId);
            var episodeCharacter = _appDbContext.EpisodeCharacter.FirstOrDefault(c => c.EpisodeId == episodeId && c.CharacterId == characterID);
            episode.Cast.Remove(episodeCharacter);
            _appDbContext.SaveChanges();
            return await Task.FromResult(episode);
        }

        public async Task<string> DeleteEpisode(int episodeId)
        {
            var episode = _appDbContext.Episodes.FirstOrDefault(f => f.Id == episodeId);
            if (episode != null)
            {
                _appDbContext.Episodes.Remove(episode);
                _appDbContext.SaveChanges();
                return await Task.FromResult("Deleted Successfully");
            }
            else {
                return await Task.FromResult("Record Not Found");
            }
            
        }
        public async Task<Episode> GetEpisode(int Id)
        {
            return await Task.FromResult(_appDbContext.Episodes.FirstOrDefault(e => e.Id == Id));
        }
        public async Task<IList<Episode>> GetEpisode()
        {
            return await Task.FromResult<IList<Episode>>(_appDbContext.Episodes.ToList());
        }
        public async Task<IList<Episode>> GetEpisodeByCharacterId(int Id)
        {
            // return list of episodes ID where Character ID  appears
            var ListofEpisodes = _appDbContext.EpisodeCharacter.Where(e => e.CharacterId == Id).Select(r=>r.EpisodeId); 
            var Episodes = _appDbContext.Episodes.Where(e => ListofEpisodes.Contains(e.Id));
            return await Task.FromResult(Episodes.ToList());
        }

    }
}
