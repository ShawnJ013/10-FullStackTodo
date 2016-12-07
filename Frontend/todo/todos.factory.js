(function() {
    'use strict';

    angular
        .module('app')
        .factory('todosFactory', todosFactory);

    todosFactory.$inject = ['$http'];

    /* @ngInject */
    function todosFactory($http) {

        var service = {

            create: create,
            getAll: getAll,
            getById: getById,
            update: update,
            remove: remove
        };
        return service;

        ////////////////
        //Methods
        // $http.post(<url>, <data>, [<options>])
        function create(post) {
            return $http.post('http://localhost:52426/api/todoes', post);
        }

        function getAll() {
            return $http.get('http://localhost:52426/api/todoes');
        }

        function getById(id) {
            return $http.get('http://localhost:52426/api/todoes' + id);

        }

        function update(id, todos) {
            return $http.put('http://localhost:52426/api/todoes' + id, post);
        }

        function remove(id) {
            return $http.delete('http://localhost:52426/api/todoes' + id);
        }
    }
})();
