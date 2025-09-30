Disaster Allowance Foundation - ASP.NET MVC Prototype
📋 Project Overview
The Disaster Allowance Foundation is a comprehensive web application designed to facilitate disaster relief efforts through user management, incident reporting, donation processing, and volunteer coordination. This ASP.NET MVC prototype demonstrates the core functionality of a disaster response management system.

🚀 Features Implemented
1. User Authentication System
Secure Registration & Login: ASP.NET Identity-based authentication

Role Management: Different user roles (Donor, Volunteer, Admin)

Profile Management: User profile creation and management

Email Confirmation: Basic email verification workflow

2. Disaster Incident Reporting
Incident Submission: Categorized disaster type reporting

Interactive Map: Visual representation of active incidents

Real-time Tracking: Status updates and severity indicators

Form Validation: Client and server-side validation

3. Donation Management System
Multiple Donation Types: Financial, supplies, or combined donations

Payment Integration: Support for multiple payment methods

Impact Tracking: Statistics and progress visualization

Anonymous Donations: Option for anonymous contributions

4. Volunteer Coordination
Volunteer Registration: Skills-based registration system

Opportunity Management: Categorized volunteer opportunities

Urgency Indicators: Priority-based task assignment

Availability Tracking: Flexible scheduling system

🛠 Technology Stack
Backend
Framework: ASP.NET MVC 5 / ASP.NET Core MVC

Authentication: ASP.NET Identity

Database: Entity Framework with SQL Server

Validation: Data Annotations & Fluent Validation

Frontend
UI Framework: Bootstrap 5.3.0

Icons: Font Awesome 6.4.0

Maps: Leaflet.js for interactive mapping

JavaScript: jQuery for dynamic interactions

Development Tools
Version Control: Git with Azure DevOps

CI/CD: Azure Pipelines

Project Management: Azure Boards

📁 Project Structure
text
APPR_P_2/
├── Controllers/
│   ├── AccountController.cs
│   ├── DonationController.cs
│   ├── VolunteerController.cs
│   └── HomeController.cs
├── Models/
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── DonationViewModel.cs
│   ├── VolunteerViewModel.cs
│   └── IncidentReportViewModel.cs
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── Donation/
│   │   └── Donate.cshtml
│   ├── Volunteer/
│   │   └── Volunteer.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── ReportIncident.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── Content/
│   └── Site.css
└── Scripts/
    └── Custom/
🗄 Database Schema
Core Tables
Users: User accounts and authentication

Donations: Financial and supply donation records

IncidentReports: Disaster incident tracking

Volunteers: Volunteer profiles and skills

InventoryItems: Supply catalog management

ReliefProjects: Disaster relief project coordination

Key Relationships
One-to-Many: Users → Donations

One-to-Many: Users → IncidentReports

Many-to-Many: Volunteers → Skills

Many-to-Many: ReliefProjects → InventoryItems

🚀 Getting Started
Prerequisites
.NET Framework 4.8 or .NET 6+

SQL Server 2016+

Visual Studio 2022+

Git

Installation Steps
Clone the Repository

bash
git clone https://dev.azure.com/your-organization/DisasterAllowanceFoundation/_git/DisasterAllowanceFoundation
cd APPR_P_2
Database Setup

sql
-- Run initial migration or database script
Update-Database
Configuration

Update connection strings in Web.config

Configure email settings for notifications

Set up payment gateway credentials

Build and Run

bash
dotnet build
dotnet run
Access Application

Navigate to https://localhost:7000

Default admin credentials in seed data

🧪 Testing
Unit Tests
bash
dotnet test
Integration Tests
Database connectivity tests

Payment gateway integration tests

Email service tests

User Acceptance Testing
Donor Flow: Registration → Donation → Confirmation

Volunteer Flow: Registration → Skill selection → Opportunity application

Admin Flow: User management → Incident monitoring → Reporting

🔧 Configuration
App Settings
xml
<appSettings>
  <add key="PaymentGateway:ApiKey" value="your-api-key"/>
  <add key="Email:SmtpServer" value="smtp.gmail.com"/>
  <add key="Email:Port" value="587"/>
  <add key="MapService:ApiKey" value="your-map-api-key"/>
</appSettings>
Environment Variables
ASPNETCORE_ENVIRONMENT: Development/Production

DATABASE_CONNECTION: Connection string

PAYMENT_GATEWAY_URL: Payment service endpoint

📊 API Endpoints
Authentication
POST /Account/Login - User authentication

POST /Account/Register - User registration

POST /Account/ForgotPassword - Password recovery

Donations
GET /Donation/Donate - Donation form

POST /Donation/ProcessDonation - Process donation

GET /Donation/ThankYou - Donation confirmation

Volunteers
GET /Volunteer/Index - Volunteer opportunities

POST /Volunteer/RegisterVolunteer - Volunteer registration

GET /Volunteer/ThankYou - Registration confirmation

Incidents
GET /Home/ReportIncident - Incident reporting form

POST /Home/ReportIncident - Submit incident report

GET /Home/Incidents - View active incidents

🛡 Security Features
Password Hashing: PBKDF2 with salt

CSRF Protection: Anti-forgery tokens

SQL Injection Prevention: Parameterized queries

XSS Protection: Input sanitization

Role-based Authorization: Access control

HTTPS Enforcement: Secure communication

📈 Performance Optimization
Database
Indexed frequently queried columns

Query optimization and caching

Connection pooling

Application
Client-side validation

AJAX for dynamic content

Bundled and minified assets

CDN for static resources

🤝 Contributing
Development Workflow
Fork the repository

Create feature branch (git checkout -b feature/AmazingFeature)

Commit changes (git commit -m 'Add AmazingFeature')

Push to branch (git push origin feature/AmazingFeature)

Open Pull Request

Code Standards
Follow ASP.NET MVC best practices

Use meaningful commit messages

Include unit tests for new features

Update documentation accordingly

📝 License
This project is licensed under the MIT License - see the LICENSE.md file for details.

🆘 Support
For support and questions:

📧 Email: support@disasterallowance.org

📋 Issues: GitHub Issues

📚 Documentation: Project Wiki

🙏 Acknowledgments
Bootstrap team for the responsive UI framework

Font Awesome for comprehensive icon set

Leaflet.js for interactive mapping capabilities

ASP.NET community for best practices and guidance

Note: This is a prototype implementation. For production deployment, additional security measures, error handling, and performance optimizations are recommended.
