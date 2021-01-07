// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/vatereng.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace VateraEng2 {
  public static partial class Vatera
  {
    static readonly string __ServiceName = "vatera.Vatera";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::VateraEng2.User> __Marshaller_vatera_User = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.User.Parser));
    static readonly grpc::Marshaller<global::VateraEng2.Session_Id> __Marshaller_vatera_Session_Id = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.Session_Id.Parser));
    static readonly grpc::Marshaller<global::VateraEng2.Result> __Marshaller_vatera_Result = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.Result.Parser));
    static readonly grpc::Marshaller<global::VateraEng2.Data> __Marshaller_vatera_Data = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.Data.Parser));
    static readonly grpc::Marshaller<global::VateraEng2.Empty> __Marshaller_vatera_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.Empty.Parser));
    static readonly grpc::Marshaller<global::VateraEng2.Data2> __Marshaller_vatera_Data2 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::VateraEng2.Data2.Parser));

    static readonly grpc::Method<global::VateraEng2.User, global::VateraEng2.Session_Id> __Method_Login = new grpc::Method<global::VateraEng2.User, global::VateraEng2.Session_Id>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_vatera_User,
        __Marshaller_vatera_Session_Id);

    static readonly grpc::Method<global::VateraEng2.Session_Id, global::VateraEng2.Result> __Method_Logout = new grpc::Method<global::VateraEng2.Session_Id, global::VateraEng2.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Logout",
        __Marshaller_vatera_Session_Id,
        __Marshaller_vatera_Result);

    static readonly grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result> __Method_Add = new grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_vatera_Data,
        __Marshaller_vatera_Result);

    static readonly grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result> __Method_Delete = new grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_vatera_Data,
        __Marshaller_vatera_Result);

    static readonly grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result> __Method_Update = new grpc::Method<global::VateraEng2.Data, global::VateraEng2.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_vatera_Data,
        __Marshaller_vatera_Result);

    static readonly grpc::Method<global::VateraEng2.Empty, global::VateraEng2.Data2> __Method_Display = new grpc::Method<global::VateraEng2.Empty, global::VateraEng2.Data2>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Display",
        __Marshaller_vatera_Empty,
        __Marshaller_vatera_Data2);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::VateraEng2.VaterengReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Vatera</summary>
    public partial class VateraClient : grpc::ClientBase<VateraClient>
    {
      /// <summary>Creates a new client for Vatera</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public VateraClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Vatera that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public VateraClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected VateraClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected VateraClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::VateraEng2.Session_Id Login(global::VateraEng2.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Login(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::VateraEng2.Session_Id Login(global::VateraEng2.User request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Login, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Session_Id> LoginAsync(global::VateraEng2.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Session_Id> LoginAsync(global::VateraEng2.User request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Login, null, options, request);
      }
      public virtual global::VateraEng2.Result Logout(global::VateraEng2.Session_Id request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Logout(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::VateraEng2.Result Logout(global::VateraEng2.Session_Id request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Logout, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> LogoutAsync(global::VateraEng2.Session_Id request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LogoutAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> LogoutAsync(global::VateraEng2.Session_Id request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Logout, null, options, request);
      }
      public virtual global::VateraEng2.Result Add(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::VateraEng2.Result Add(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> AddAsync(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> AddAsync(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
      }
      public virtual global::VateraEng2.Result Delete(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Delete(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::VateraEng2.Result Delete(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Delete, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> DeleteAsync(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> DeleteAsync(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Delete, null, options, request);
      }
      public virtual global::VateraEng2.Result Update(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Update(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::VateraEng2.Result Update(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Update, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> UpdateAsync(global::VateraEng2.Data request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::VateraEng2.Result> UpdateAsync(global::VateraEng2.Data request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Update, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::VateraEng2.Data2> Display(global::VateraEng2.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Display(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::VateraEng2.Data2> Display(global::VateraEng2.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Display, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override VateraClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new VateraClient(configuration);
      }
    }

  }
}
#endregion