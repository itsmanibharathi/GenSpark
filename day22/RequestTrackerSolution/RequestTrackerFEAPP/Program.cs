using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Channels;

namespace RequestTrackerApp
{
    internal class Program
    {

        IEmployeeLoginBL employeeLoginBL;
        IEmployeeRequestBL employeeRequestBL;
        ISolutionFeedbackBL solutionFeedbackBL;
        IRequestSolutionBL requestSolutionBL;
        Employee _employee;
        public Program()
        {
            employeeLoginBL = new EmployeeLoginBL();
            employeeRequestBL = new EmployeeRequestBL();
            solutionFeedbackBL = new SolutionFeedbackBL();
            requestSolutionBL = new RequestSolutionBL();
        }
        static async Task Main(string[] args)
        {
            await new Program().Run();
        }

        async Task Run()
        {
            Console.WriteLine("Welcome to Request Tracker");
            while (true)
            {
                if (_employee == null)
                {
                    Console.WriteLine("1. Login");
                }
                else
                {
                    Console.WriteLine("Welcome " + _employee.Name);
                    Console.WriteLine("2. LogOut");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _employee =await Login();
                        if (_employee != null)
                        {
                            Console.WriteLine("Welcome "+ _employee.Name);
                            if (_employee.Role == EmployeeRoles.Admin)
                            {
                                await AdminMenu();
                            }
                            else
                            {
                                await EmployeeMenu();
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Login failed");
                        }
                        break;
                    case 2:
                        _employee = null;
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }


        async Task<Employee> Login()
        {
            Console.Write("Please enter Employee Id :");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the Password: ");
            string password = Console.ReadLine() ?? "";
            return await EmployeeLoginAsync(id,password);
        }
        async Task<Employee> EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password,Id=username };
            return await employeeLoginBL.Login(employee);
        }


        async Task EmployeeMenu()
        {
            while (true)
            {
                Console.WriteLine("Employee Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View My Request Status");
                Console.WriteLine("3. View All My Request Status");
                Console.WriteLine("4. View My Requst Solutions");
                Console.WriteLine("5. View My Requst All Solutions");
                Console.WriteLine("6. Respond to My Solution");
                Console.WriteLine("7. ReOpen My Requst");
                Console.WriteLine("8. Colse My Request");
                Console.WriteLine("9. Give Feedback for Solution");
                Console.WriteLine("10. View All Feedbacks for me");
                Console.WriteLine("0. LogOut");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        await RaiseRequest();
                        break;
                    case 2:
                        await ViewMyRequest();
                        break;
                    case 3:
                        await ViewMyAllRequest();
                        break;
                    case 4:
                        await ViewMyReqSolutions();
                        break;
                    case 5:
                        await ViewMyAllReqSolutions();
                        break;
                    case 6:
                        await RespondSolution();
                        break;
                    case 7:
                        await ReOpenRequest();
                        break;
                    case 8:
                        await CloseRequest();
                        break;
                    case 9:
                        await Feedback();
                        break;
                    case 10:
                        await ViewMyFeedbacks();
                        break;
                    case 0:
                        _employee = null;
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        

        async Task RaiseRequest()
        {
            Console.WriteLine("New Requst");
            Console.Write("Enter your request message: ");
            string message = Console.ReadLine();
            Request request = new Request() { RequestMessage = message, RequestRaisedBy = _employee.Id };
            var response = await employeeRequestBL.Add(request);
            Console.WriteLine("Request raised with number: " + response.RequestNumber);
        }
        private async Task AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("     Employee Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View My Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. ReOpen My Requst");
                Console.WriteLine("5. Colse My Request");
                Console.WriteLine("6. Give Feedback for Solution");
                Console.WriteLine("7. View All Feedbacks for me");
                Console.WriteLine("     Admin Menu");
                Console.WriteLine("8. View All Reqeust");
                Console.WriteLine("9. View All Open Request");
                Console.WriteLine("10. Add Solution to Reqeust");
                Console.WriteLine("11. Close the Request");
                Console.WriteLine("12. View All Solutions");
                Console.WriteLine("13. View All Feedbacks for my solution");    
                Console.WriteLine("0. LogOut");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                { 
                    case 1:
                        await RaiseRequest();
                        break;
                    case 2:
                        //await ViewRequest();
                        break;
                    case 3:
                        //await ViewSolutions();
                        break;
                    case 4:
                        await ReOpenRequest();
                        break;
                    case 5:
                        await CloseRequest();
                        break;
                    case 6:
                        await Feedback();
                        break;
                    case 7:
                        await ViewMyFeedbacks();
                        break;
                    case 8:
                        await ViewAllRequest();
                        break;
                    case 9:
                        await ViewAllRequest(RequestStatus.Open);
                        break;
                    case 10:
                        await AddSolution();
                        break;
                    case 11:
                        await CloseRequest();
                        break;
                    case 12:
                        //await ViewAllSolutions();
                        break;
                    case 13:
                        await ViewAllFeedbacksForMySolution();
                        break;
                    case 0:
                        _employee = null;
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        
        public async Task ViewMyRequest()
        {
            Console.Write("Enter the Request Number: ");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await employeeRequestBL.Get(requestNumber);
            Console.WriteLine(request);
        }
        public async Task ViewMyAllRequest()
        {
            var responses = await employeeRequestBL.GetAllByEmpId(_employee.Id);
            foreach(var item in responses)
            {
                Console.WriteLine("\n" + item);
            }
        }
        public async Task ViewAllRequest(RequestStatus? requestStatus = null)
        {
            var response = await employeeRequestBL.GetAll();
            if(requestStatus != null)
            {
                response = response.Where(e => e.Status == requestStatus).ToList();
            }
            foreach (var item in response)
            {
                Console.WriteLine("\n" + item);
            }
        }



        public async Task AddSolution()
        {
            Console.Write("Enter the Request Number: ");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await employeeRequestBL.Get(requestNumber);
            if (request.Status == RequestStatus.Open)
            {
                Console.Write("Enter the Solution: ");
                string solution = Console.ReadLine() ?? "No Solution ";
                RequestSolution requestSolution = new RequestSolution() { RequestId = requestNumber, SolutionDescription = solution, SolvedBy = _employee.Id };
                var response = await requestSolutionBL.Add(requestSolution);
                Console.WriteLine("Solution added with Id: " + response.SolutionId);
                request.Status = RequestStatus.Answered;
                await employeeRequestBL.Update(request);
                await Feedback(response.SolutionId);
            }
            else
            {
                Console.WriteLine("Request is closed or answered");
            }

        }

        private async Task ViewMyReqSolutions()
        {
            Console.Write("Enter the Request Number: ");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var response = await requestSolutionBL.GetByReqID(requestNumber);
            foreach (var item in response)
            {
                Console.WriteLine("\n" + item);
            }
        }
        private async Task ViewMyAllReqSolutions()
        {   
            Console.WriteLine("ViewMyAllSolution under construction");
            //var response = await requestSolutionBL.Get(requestNumber);
            //foreach (var item in response)
            //{
            //    Console.WriteLine("\n" + item);
            //}
        }

        public async Task RespondSolution()
        {
            Console.Write("Enter the Solution id: ");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            RequestSolution requestSolution = await requestSolutionBL.Get(solutionId);
            if(requestSolution != null)
            {
                Console.Write("Enter the Response: ");
                string response = Console.ReadLine() ?? "No Response";
                requestSolution.RequestRaiserComment = response;
                var res = await requestSolutionBL.Update(requestSolution);
                if (res != null)
                {
                    Console.WriteLine("Response added");
                }
            }

            
        }






        public async Task ReOpenRequest()
        {
            Console.Write("Enter the Request Number: ");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await employeeRequestBL.Get(requestNumber);
            if (request.Status == RequestStatus.Closed || request.Status == RequestStatus.Answered)
            {
                request.Status = RequestStatus.ReOpen;
                var response = await employeeRequestBL.Update(request);
                if (response != null)
                {
                    Console.WriteLine("Request ReOpened");
                }
            }
            else
            {
                Console.WriteLine("Request is not closed or answered");
            }
        }

        public async Task CloseRequest()
        {
            Console.Write("Enter the Request Number: ");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await employeeRequestBL.Get(requestNumber);
            if (request.Status != RequestStatus.Closed)
            {
                request.Status = RequestStatus.Closed;
                var response = await employeeRequestBL.Update(request);
                if (response != null)
                {
                    Console.WriteLine("Request Closed");
                }
            }
            else
            {
                Console.WriteLine("already Requst is Closed");
            }
        }


        async Task Feedback( int? solutionId = null )
        {
            Console.Write("Did you want to give the feedback (y,n): ");
            string option = Console.ReadLine();
            if (solutionId == null)
            {
                Console.Write("Enter the Solution Id: ");
                solutionId = Convert.ToInt32(Console.ReadLine());
            }
            if (option == "y")
            {
                Console.Write("Enter the feedback: ");
                string feedbackMessage = Console.ReadLine();
                Console.Write("Rate 1 to 5: ");
                int rating = Convert.ToInt32(Console.ReadLine());
                SolutionFeedback solutionFeedback = new SolutionFeedback() { SolutionId = (int) solutionId, Remarks = feedbackMessage,Rating = rating, FeedbackBy = _employee.Id};
               var res= await solutionFeedbackBL.Add(solutionFeedback);
                if (res != null)
                {
                    Console.WriteLine("\n    !!!Thank you for the feedback!!!\n");
                }
            }
        }
        private async Task ViewAllFeedbacksForMySolution()
        {
            Console.WriteLine("ViewAllFeedbacks is Under Construction");
            //var response = await solutionFeedbackBL.GetAllByEmpId(_employee.Id);
            //foreach (var item in response)
            //{
            //    Console.WriteLine("\n" + item);
            //}
        }
        private async Task ViewMyFeedbacks()
        {
            Console.WriteLine("ViewMyFeedbacks is Under Construction");
            //var response = await solutionFeedbackBL.GetAllByEmpId(_employee.Id);
            //foreach (var item in response)
            //{
            //    Console.WriteLine("\n" + item);
            //}
        }


    }
}
