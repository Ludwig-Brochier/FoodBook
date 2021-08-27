﻿using BO.DTO.Modeles;
using BO.DTO.Reponses;
using BO.DTO.Requetes;
using BO.Entite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BLLC.Extensions;

namespace BLLC.Services
{
    public class RestaurationService : IRestaurationService
    {
        private readonly HttpClient _httpClient;
        public RestaurationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        #region Ingredient
        public async Task<ReponsePagination<Ingredient>> GetAllIngredientsAsync(RequetePagination requetePagination)
        {
            return await _httpClient.GetFromJsonAsync<ReponsePeriodique<Ingredient>>($"ingredients{requetePagination.ToUriQuery()}");
        }

        public async Task<Ingredient> GetIngredientAsync(int idIngredient)
        {
            return await _httpClient.GetFromJsonAsync<Ingredient>($"ingredients/{idIngredient}");
        }
        #endregion

        #region Plat
        public async Task<ReponsePagination<Plat>> GetAllPlatsAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            return await _httpClient.GetFromJsonAsync<ReponsePagination<Plat>>($"plats{requeteFiltresPlats.ToUriQuery()}");
        }

        public async Task<ReponsePagination<PlatPopulaire>> GetAllPlatsPopulaireAsync(RequeteFiltresPlats requeteFiltresPlats)
        {
            return await _httpClient.GetFromJsonAsync<ReponsePagination<PlatPopulaire>>($"plats{requeteFiltresPlats.ToUriQuery()}");
        }

        public async Task<Plat> GetPlatAsync(int idPlat)
        {
            return await _httpClient.GetFromJsonAsync<Plat>($"plats/{idPlat}");
        }
        
        public async Task<Plat> InsertPlatAsync(Plat plat)
        {
            var reponse = await _httpClient.PostAsJsonAsync("plats", plat);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Plat newPlat = await JsonSerializer.DeserializeAsync<Plat>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newPlat;
            }
        }

        public async Task<Plat> UpdatePlatAsync(Plat plat)
        {
            var reponse = await _httpClient.PutAsJsonAsync("plat/" + plat.IdPlat, plat);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Plat newPlat = await JsonSerializer.DeserializeAsync<Plat>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newPlat;
            }
        }

        public async Task<bool> DeletePlatAsync(int idPlat)
        {
            var reponse = await _httpClient.DeleteAsync($"plats/{idPlat}");

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        #endregion

        #region Menu
        public async Task<ReponsePeriodique<Menu>> GetAllMenusAsync(RequetePeriodique requetePeriodique)
        {
            return await _httpClient.GetFromJsonAsync<ReponsePeriodique<Menu>>($"menus{requetePeriodique.ToUriQuery()}");
        }

        public async Task<Menu> GetMenuAsync(int idMenu)
        {
            return await _httpClient.GetFromJsonAsync<Menu>($"menus/{idMenu}");
        }

        public async Task<Menu> InsertMenuAsync(Menu menu)
        {
            var reponse = await _httpClient.PostAsJsonAsync("menus", menu);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Menu newMenu = await JsonSerializer.DeserializeAsync<Menu>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newMenu;
            }
        }

        public async Task<Menu> UpdateMenuAsync(Menu menu)
        {
            var reponse = await _httpClient.PutAsJsonAsync("menus/" + menu.IdMenu, menu);
            using (var stream = await reponse.Content.ReadAsStreamAsync())
            {
                Menu newMenu = await JsonSerializer.DeserializeAsync<Menu>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return newMenu;
            }
        }

        public async Task<bool> DeleteMenuAsync(int idMenu)
        {
            var reponse = await _httpClient.DeleteAsync($"menus/{idMenu}");

            if (reponse.IsSuccessStatusCode)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        #endregion
    }
}