﻿namespace ProductManagement.Infrastructure.CacheKeys
{
    public static class CategoryCacheKeys
    {
        public static string ListKey => "CategoryList";

        public static string SelectListKey => "CategorieselectList";

        public static string GetKey(int CategoryId) => $"Category-{CategoryId}";

        public static string GetDetailsKey(int CategoryId) => $"CategoryDetails-{CategoryId}";
    }
}