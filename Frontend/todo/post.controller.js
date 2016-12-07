(function() {
    'use strict';

    angular
        .module('app')
        .controller('PostController', PostController);

    PostController.$inject = ['todosFactory'];
    // vm.sort = 'priority';

    /* @ngInject */
    function PostController(todosFactory) {

        var vm = this;

        vm.title = 'PostController',
            vm.addPost = addPost;

        vm.posts = [];
        // vm.addTodos = addTodos
        vm.deleteTodos = deleteTodos;
        vm.getClass = getClass;

        activate();

        //////////////////////
        function activate() {
            todosFactory
                .getAll() 
                .then(function(response) {
                    vm.todo = response.data;

                });
        }

        vm.sort = "priority";

        function deleteTodos(post) {
            todosFactory
                .remove(post.Id)
                .then(function(response) {
                    var index = vm.posts.indexOf(post);

                    vm.posts.splice(index, 1);

                })
        }



        function getClass(todos) {
            switch (todos.priority) {
                case 1:
                    return 'list-group-item-danger';
                case 2:
                    return 'list-group-item-danger';
                case 3:
                    return 'list-group-item-danger';

            }
        }

        function addPost() {
            todosFactory
                .create(vm.newPost)
                .then(function(response) {
                    vm.posts.push(response.data);

                    vm.newTodo = {};

                })
                .catch(function(error) {

                });


        }
    }

})()
