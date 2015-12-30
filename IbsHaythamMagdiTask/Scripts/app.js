

(function () {


    //var app = angular.module('myTaskApp', []);
    //angular.module('myTaskApp', []);

    //angular.module('myTaskApp')


    //app.constant("usersApiUrl", "/api/usersapi");


    angular.module('myTaskApp')


        .constant("usersApiUrl", "/api/usersapi")

    //app.controller('UsersController', ['$http', '$scope', 'usersApiUrl', function ($http, $scope, usersApiUrl) {

    //app.controller('UsersController', function ($http, $scope, usersApiUrl) {


        .controller('UsersController', function ($http, $scope, usersApiUrl) {


            debugger;

            var ctrl = this;

            this.srchEmail = '';

            this.users = {};

            this.selUser = {};

            this.GetUsers = function () {

                debugger;

                //$http({
                //    method: 'GET',
                //    url: '/api/usersapi',
                //    params: { email: email }
                //}).then(function successCallback(data) {

                //$http.get('/api/usersapi', { params: { email: ctrl.srchEmail } }).success(function (data) {
                $http.get(usersApiUrl, { params: { email: ctrl.srchEmail } })
                    .success(function (data) {

                        debugger;

                        ctrl.users = data;

                        //$scope...init();

                    })
                .error(function (data) {

                    debugger;

                    //ctrl.users = data;

                    //$scope...init();

                });
            }


            this.EditMode = 'N';

            this.Try1 = function () {

                debugger;

                var em = this.errorMsg;

                //em = undefined;

                var isDefined1 = angular.isDefined(this.errorMsg);
                //var in1 = angular.isNull(this.errorMsg);
                var in1 = this.errorMsg === null;

                debugger;

            }

            this.PrepareEdit = function (user) {
                this.EditMode = 'E';
                this.selUser = user;
            }

            this.PrepareAdd = function () {
                this.EditMode = 'A';
                this.selUser = {};
            }

            this.IsEditing = function () {
                return this.EditMode === 'E';
            }

            this.IsAdding = function () {
                return this.EditMode === 'A';
            }

            this.UpdateSelUser = function () {

                this.errorMsg = undefined;

                debugger;

                //ctrl.selUser.Iner1 = { P1: 'p1', P2: 'p2' };
                //ctrl.selUser.Iner2 = ['e1', 'e2'];

                ctrl.selUser.UserComments = [];

                ctrl.selUser.UserComments.push({ Id: 1, UserId: ctrl.selUser.Id, Comment: 'comm1' });
                ctrl.selUser.UserComments.push({ Id: 2, UserId: ctrl.selUser.Id, Comment: 'comm2' });


                $http({
                    method: 'PUT',
                    url: usersApiUrl,
                    //headers: {
                    //    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                    //},

                    //params: { user: ctrl.selUser }

                    params: {
                        Id: ctrl.selUser.Id,
                        //FirstName: ctrl.selUser.FirstName,
                        //LastName: 'last55',
                        userJson: ctrl.selUser
                    }

                }).then(function successCallback(data) {

                    ctrl.GetUsers();
                });

                //this.users.push(this.selUser);

                ////$scope.$apply(function () {
                //    $scope.$digest(function () {


                //});
                //this.GetUsers();
            }

            this.DeleteUser = function (userId) {

                this.errorMsg = undefined;

                $http({
                    method: 'DELETE',
                    url: usersApiUrl,

                    params: {
                        id: userId
                    }

                }).success(function (data) {

                    debugger;

                    ctrl.GetUsers();
                }).error(function (data) {

                    debugger;

                    ctrl.errorMsg = data.Message;
                });

                //this.users.push(this.selUser);

                ////$scope.$apply(function () {
                //    $scope.$digest(function () {


                //});

                this.GetUsers();
            }

            this.AddSelUser = function () {

                debugger;

                $http({
                    method: 'POST',
                    url: usersApiUrl,
                    //headers: {
                    //    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                    //},

                    //params: { user: ctrl.selUser }
                    params: {
                        FirstName: ctrl.selUser.FirstName
                    }

                }).then(function successCallback(data) {

                    debugger;

                    ctrl.GetUsers();
                });

            }

            this.Activate = function (userId, active) {

                this.errorMsg = undefined;

                debugger;

                $http({
                    method: 'POST',
                    url: '/users/Activate',

                    params: {
                        userId: userId,
                        active: active
                    }
                }).then(function successCallback(data) {

                    debugger;

                    ctrl.GetUsers();
                });

            }




            //}]);
        });






})();
