#pragma checksum "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a0fb9c22c88ad14fca35a88887dd09a9bddf598"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\_ViewImports.cshtml"
using Kursach;

#line default
#line hidden
#line 2 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\_ViewImports.cshtml"
using Kursach.Models;

#line default
#line hidden
#line 3 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\_ViewImports.cshtml"
using Kursach.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a0fb9c22c88ad14fca35a88887dd09a9bddf598", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf560d7e18636cd7b9c7e9b8c2af118667e29b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProjectModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Projects";
    bool hasSteps = false;

#line default
#line hidden
            BeginContext(106, 168, true);
            WriteLiteral("\r\n<nav class=\"navbar navbar-light bg-light\">\r\n    <span class=\"navbar-brand mb-0 h1\">Количество проектов с вашим участием: <span class=\"badge badge-primary badge-pill\">");
            EndContext();
            BeginContext(275, 13, false);
#line 8 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                                                                                                     Write(Model.Count());

#line default
#line hidden
            EndContext();
            BeginContext(288, 28, true);
            WriteLiteral("</span></span>\r\n</nav>\r\n\r\n\r\n");
            EndContext();
#line 12 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
 foreach (var project in Model)
{

#line default
#line hidden
            BeginContext(352, 72, true);
            WriteLiteral("<ul class=\"list-group\">\r\n\r\n\r\n    <li class=\"list-group-item active\">\r\n\r\n");
            EndContext();
#line 19 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
         foreach (var st in project.Steps)
        {
            if (st.EndDate == DateTime.MinValue)
            {
                hasSteps = true;
            }
        }

#line default
#line hidden
            BeginContext(604, 101, true);
            WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"inline\" style=\"float:left\">\r\n                <b>");
            EndContext();
            BeginContext(706, 19, false);
#line 29 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
              Write(project.ProjectName);

#line default
#line hidden
            EndContext();
            BeginContext(725, 28, true);
            WriteLiteral("</b>\r\n            </div>\r\n\r\n");
            EndContext();
#line 32 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
             if (!project.IsDone && project.AuthorId == int.Parse(User.Identity.Name) && !hasSteps)
            {
                

#line default
#line hidden
#line 34 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 using (Html.BeginForm("UpdateProjStatus", "Home", FormMethod.Post))
                {


#line default
#line hidden
            BeginContext(976, 145, true);
            WriteLiteral("                    <div class=\"inline\" style=\"margin-right: 10px\">\r\n                        <input type=\"hidden\" id=\"projectID\" name=\"projectId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1121, "", 1144, 1);
#line 38 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 1128, project.Project, 1128, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1144, 130, true);
            WriteLiteral(">\r\n                        <input type=\"submit\" class=\"btn btn-success\" value=\"Завершить проект \" />\r\n                    </div>\r\n");
            EndContext();
#line 41 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#line 41 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1308, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 43 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
             if (!project.IsDone)
            {
                

#line default
#line hidden
#line 45 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 using (Html.BeginForm("AddStep", "Home", FormMethod.Post))
                {

#line default
#line hidden
            BeginContext(1454, 145, true);
            WriteLiteral("                    <div class=\"inline\" style=\"margin-right: 10px\">\r\n                        <input type=\"hidden\" id=\"projectID\" name=\"projectId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1599, "", 1622, 1);
#line 48 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 1606, project.Project, 1606, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1622, 83, true);
            WriteLiteral(">\r\n                        <input type=\"hidden\" id=\"projectName\" name=\"projectName\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1705, "", 1732, 1);
#line 49 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 1712, project.ProjectName, 1712, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1732, 124, true);
            WriteLiteral(">\r\n                        <input type=\"submit\" class=\"btn btn-info\" value=\"Добавить этап \" />\r\n                    </div>\r\n");
            EndContext();
#line 52 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#line 52 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1890, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 55 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
             if (!project.IsDone && project.AuthorId == int.Parse(User.Identity.Name))
            {
                

#line default
#line hidden
#line 57 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 using (Html.BeginForm("AddUserView", "Home", FormMethod.Post))
                {


#line default
#line hidden
            BeginContext(2097, 149, true);
            WriteLiteral("                    <div class=\"inline\" style=\"margin-right: 10px\">\r\n                        <input type=\"hidden\" id=\"projectName\" name=\"projectName\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 2246, "", 2273, 1);
#line 61 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 2253, project.ProjectName, 2253, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2273, 79, true);
            WriteLiteral(">\r\n                        <input type=\"hidden\" id=\"projectID\" name=\"projectId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 2352, "", 2375, 1);
#line 62 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 2359, project.Project, 2359, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2375, 133, true);
            WriteLiteral(">\r\n                        <input type=\"submit\" class=\"btn btn-warning\" value=\"Управление доступом \" />\r\n                    </div>\r\n");
            EndContext();
#line 65 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#line 65 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(2542, 82, true);
            WriteLiteral("        </div>\r\n\r\n\r\n    </li>\r\n    <li class=\"list-group-item\"><b>Стоимость</b> - ");
            EndContext();
            BeginContext(2625, 12, false);
#line 71 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                              Write(project.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(2637, 58, true);
            WriteLiteral(" $</li>\r\n    <li class=\"list-group-item\"><b>Дедлайн</b> - ");
            EndContext();
            BeginContext(2696, 36, false);
#line 72 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                            Write(project.Deadline.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(2732, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 73 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
     if (project.IsDone)
    {

#line default
#line hidden
            BeginContext(2772, 82, true);
            WriteLiteral("        <li class=\"list-group-item list-group-item-success\">Проект завершен</li>\r\n");
            EndContext();
#line 76 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2878, 95, true);
            WriteLiteral("        <li class=\"list-group-item list-group-item-danger\">Проект находится в разработке</li>\r\n");
            EndContext();
#line 80 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(2980, 19, true);
            WriteLiteral("   \r\n\r\n    <br />\r\n");
            EndContext();
#line 84 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
     foreach (var step in project.Steps)
    {

#line default
#line hidden
            BeginContext(3048, 226, true);
            WriteLiteral("        <ul class=\"nested\">\r\n            <li class=\"list-group-item list-group-item-info\">\r\n                <div class=\"row\">\r\n                    <div class=\"inline\" style=\"float:left\">\r\n                        <b>Этап: </b> ");
            EndContext();
            BeginContext(3275, 9, false);
#line 90 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                 Write(step.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3284, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 92 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                     if (step.EndDate == DateTime.MinValue)
                    {
                        

#line default
#line hidden
#line 94 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                         using (Html.BeginForm("UpdateStepStatus", "Home", FormMethod.Post))
                        {

#line default
#line hidden
            BeginContext(3517, 104, true);
            WriteLiteral("<div class=\"text-right\">\r\n                                <input type=\"hidden\" id=\"stepID\" name=\"stepId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 3621, "", 3651, 1);
#line 96 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 3628, step.StepOfDevelopment, 3628, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3651, 138, true);
            WriteLiteral(">\r\n                                <input type=\"submit\" class=\"btn btn-primary\" value=\"Завершить\" />\r\n                            </div>\r\n");
            EndContext();
#line 99 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#line 99 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(3839, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 101 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                     if (project.AuthorId == int.Parse(User.Identity.Name))
                    {
                        

#line default
#line hidden
#line 103 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                         using (Html.BeginForm("RemoveStepFromProject", "Home", FormMethod.Post))
                        {

#line default
#line hidden
            BeginContext(4063, 128, true);
            WriteLiteral("<div class=\"inline\" style=\"margin-right : 10px\">\r\n                                <input type=\"hidden\" id=\"stepID\" name=\"stepId\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 4191, "", 4221, 1);
#line 105 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
WriteAttributeValue("", 4198, step.StepOfDevelopment, 4198, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4221, 156, true);
            WriteLiteral(">\r\n                                <button type=\"submit\" class=\"btn btn-primary\" value=\"Удалить\"><span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\">");
            EndContext();
            BeginContext(4378, 22, false);
#line 106 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                                                                                                                                    Write(step.StepOfDevelopment);

#line default
#line hidden
            EndContext();
            BeginContext(4400, 54, true);
            WriteLiteral("</span></button>\r\n                            </div>\r\n");
            EndContext();
#line 108 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#line 108 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(4504, 76, true);
            WriteLiteral("            </li>\r\n            <li class=\"list-group-item\"><b>Описание:</b> ");
            EndContext();
            BeginContext(4581, 16, false);
#line 111 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                                    Write(step.Description);

#line default
#line hidden
            EndContext();
            BeginContext(4597, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 112 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
             if (step.EndDate != DateTime.MinValue)
            {

#line default
#line hidden
            BeginContext(4672, 82, true);
            WriteLiteral("                <li class=\"list-group-item list-group-item-success\">Этап завершен ");
            EndContext();
            BeginContext(4755, 32, false);
#line 114 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
                                                                             Write(step.EndDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(4787, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 115 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(4842, 100, true);
            WriteLiteral("                <li class=\"list-group-item list-group-item-danger\">Этап в процессе выполнения</li>\r\n");
            EndContext();
#line 119 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(4957, 31, true);
            WriteLiteral("        </ul>\r\n        <hr />\r\n");
            EndContext();
#line 122 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(4995, 7, true);
            WriteLiteral("</ul>\r\n");
            EndContext();
#line 124 "C:\Users\Alex\documents\visual studio 2017\Projects\Kursach\Kursach\Views\Home\Index.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProjectModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
