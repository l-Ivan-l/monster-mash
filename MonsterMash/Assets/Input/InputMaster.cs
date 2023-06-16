// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""GameplayActions"",
            ""id"": ""659a5f28-4c72-4ac8-ac02-4aaf6f704fd2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a228ea85-1aab-4cc5-9d44-4980b5c23388"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone(min=0.95,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stomp"",
                    ""type"": ""Button"",
                    ""id"": ""9eb1d891-6e03-4714-a303-c91f5659cc0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowsMove"",
                    ""id"": ""febc68e8-fd55-4793-91b4-818b4da3b1b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d12aa651-cc0d-4f8c-b5f7-949ff4ac1af3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""576c1a6e-f7f9-4cc5-a85b-2d603344d2ed"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0788ec23-5c13-461c-ac8b-4fc96448b727"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69a8fe6c-edae-4594-8578-904131ca05ed"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASDMove"",
                    ""id"": ""8c29cdef-06a0-4a87-9761-0ad7b9c1ed7e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d806206d-e556-4378-a616-76d2526a82c4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""00eed4a5-986f-4c53-b95e-cdf633700b6f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1bfd2851-0f8a-467e-bd4d-d0c9891295ac"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""320a3a98-76f7-4341-8571-bbebcea61812"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GenericJoystickMove"",
                    ""id"": ""90a5b8a8-f818-47c4-a1b7-001b979b4b40"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""abb9cca3-e17a-4725-bc63-fff9b7a50cb0"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1301ecbd-c22d-44a0-9d2e-7478462fa372"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8948e2f1-8b03-4607-ad3e-1d8795e8db4c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40a1a92c-2971-4053-b287-1bd2925ed426"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PSJoystickMove"",
                    ""id"": ""d5dbabcb-f21d-49f2-bdda-2c6fc4f7dcad"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3311e0f8-1c1d-4984-ad4c-8702c6dc7b1d"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""13d4b07d-fad4-4509-8e11-de700263a8c0"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""56af1b79-df52-4ee9-a75c-10747c7f5bcd"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""841b6821-d5fe-4689-9d8e-0a274b1b022e"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""77d77f5e-cabf-4382-969c-9761bbbb70c6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Stomp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""235769ed-0ec8-4edb-90df-d28f72f3914d"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Stomp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bab36e9-99e0-4b78-94c6-ab46a3e06a6b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Stomp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GenericDpadMove"",
                    ""id"": ""8eaa26b6-a2fd-429d-b779-e0aa5439cec1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7602991d-2d4c-402c-bff9-fdad1204c9d9"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3a3fba4f-f1eb-4f34-b8dd-631c5d12f52c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4b41912-7b79-4e2a-8945-3dc066899c82"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1ad72d15-c15a-41d8-a70c-47747111e318"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PSDpadMove"",
                    ""id"": ""15491e30-5be9-43ce-9730-a2ba3c17a6c6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b8cc94d0-561d-42fb-bb81-c896c710c89c"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e36e1464-6787-4a0a-9916-3fb06029de99"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b4ebca90-6f44-48c7-b441-7eedf238867c"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4c7544f-0e42-40c9-b349-4971fa1835dc"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UIActions"",
            ""id"": ""8980365b-1331-47a1-994f-a84c8ed8f4e7"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ec25d5ce-c2a7-4d6f-a72c-62e3362be8e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone(min=0.95,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b7ee9dc-8d8d-4ed8-84c8-1f4208c876b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASDMove"",
                    ""id"": ""0ebed5a3-1145-4e24-98f8-f55996019eb9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1bc8838d-19f6-4b22-a2d6-1edc9adeccaa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""83c41fbd-d20d-4acc-b75a-72ebcf37ed24"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c2686b00-2f7b-438d-a263-4ae0f6ef151d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44adce22-f9b6-457b-87ea-096d907fd533"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowsMove"",
                    ""id"": ""d58600dc-ba0f-48dc-8a8e-288f26b42eee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""72ebecdc-5ba6-40c1-b55f-7ad48f6a2b35"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9cd95ff9-8df9-44dc-9c37-f10b80f24808"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc398931-a74f-4488-9df6-acaf9e2d81f9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e7177c7-8772-4f6b-8a98-af010ef6aca0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GenericJoystickMove"",
                    ""id"": ""254377c5-f45d-4ae0-9b87-955d677dd9b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1d465d0f-d9fa-42d7-a7b3-dc365b7dac40"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ccada344-4aac-49f5-a1d9-55216e8878ce"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2ef45537-b844-4140-a821-0f31719fef66"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b75952f0-3c12-4d20-9f56-027e81430ca4"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GenericDpadMove"",
                    ""id"": ""7d280d7f-4ba0-4990-926e-5747a79e6362"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""176902b7-7b0e-4fec-a06d-8ca1e9ccabdf"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""26a496ec-c8fc-4c3c-8f85-b0f62934fea8"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b030445-464a-4323-9f5e-b9fcbd1db606"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b45363ab-7e0b-4a94-9471-48dbb577c6c0"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1cc6d8ff-a399-401d-a259-b28a73fea361"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc7cd158-0504-46bd-b4d5-acbb288fa40c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d401096-b999-47d4-90ff-c2b40bec3baa"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""PSJoystickMove"",
                    ""id"": ""1d6a8716-5c02-4adb-a4dd-9735e0a4585a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5ea8e467-6c2d-4134-b325-13d989ca57c4"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2681b76a-a28e-46bd-89d2-8468fbd0722d"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f761db06-1d44-4fe6-8bb3-f2dd004549a1"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""51e5f999-d8de-49a0-be00-885d44f064d0"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PSDpadMove"",
                    ""id"": ""22be6543-7d7b-4bae-95c2-ff4f5915c16a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1000d86-86bd-4aba-9fb4-b16a6b36470c"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bd310ae2-de88-4155-a8dd-f017c55f02be"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eaf31915-234d-48dd-98a6-fb795bb3d5dc"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1278c7f8-ccb8-4225-88a0-7bae487282e8"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""244b70ab-9f79-4856-ad6c-e6d85dd24253"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EditorActions"",
            ""id"": ""7bbaa1da-bb14-46f1-816b-ea7fbede7c85"",
            ""actions"": [
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""c9b0ce4f-c1d4-4ac7-b08e-f4d2c2f143c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77ee84d0-b038-49c2-9b89-72e67170d87e"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameplayActions
        m_GameplayActions = asset.FindActionMap("GameplayActions", throwIfNotFound: true);
        m_GameplayActions_Move = m_GameplayActions.FindAction("Move", throwIfNotFound: true);
        m_GameplayActions_Stomp = m_GameplayActions.FindAction("Stomp", throwIfNotFound: true);
        // UIActions
        m_UIActions = asset.FindActionMap("UIActions", throwIfNotFound: true);
        m_UIActions_Navigate = m_UIActions.FindAction("Navigate", throwIfNotFound: true);
        m_UIActions_Submit = m_UIActions.FindAction("Submit", throwIfNotFound: true);
        // EditorActions
        m_EditorActions = asset.FindActionMap("EditorActions", throwIfNotFound: true);
        m_EditorActions_Reset = m_EditorActions.FindAction("Reset", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GameplayActions
    private readonly InputActionMap m_GameplayActions;
    private IGameplayActionsActions m_GameplayActionsActionsCallbackInterface;
    private readonly InputAction m_GameplayActions_Move;
    private readonly InputAction m_GameplayActions_Stomp;
    public struct GameplayActionsActions
    {
        private @InputMaster m_Wrapper;
        public GameplayActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GameplayActions_Move;
        public InputAction @Stomp => m_Wrapper.m_GameplayActions_Stomp;
        public InputActionMap Get() { return m_Wrapper.m_GameplayActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActionsActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActionsActions instance)
        {
            if (m_Wrapper.m_GameplayActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnMove;
                @Stomp.started -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnStomp;
                @Stomp.performed -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnStomp;
                @Stomp.canceled -= m_Wrapper.m_GameplayActionsActionsCallbackInterface.OnStomp;
            }
            m_Wrapper.m_GameplayActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Stomp.started += instance.OnStomp;
                @Stomp.performed += instance.OnStomp;
                @Stomp.canceled += instance.OnStomp;
            }
        }
    }
    public GameplayActionsActions @GameplayActions => new GameplayActionsActions(this);

    // UIActions
    private readonly InputActionMap m_UIActions;
    private IUIActionsActions m_UIActionsActionsCallbackInterface;
    private readonly InputAction m_UIActions_Navigate;
    private readonly InputAction m_UIActions_Submit;
    public struct UIActionsActions
    {
        private @InputMaster m_Wrapper;
        public UIActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UIActions_Navigate;
        public InputAction @Submit => m_Wrapper.m_UIActions_Submit;
        public InputActionMap Get() { return m_Wrapper.m_UIActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActionsActions set) { return set.Get(); }
        public void SetCallbacks(IUIActionsActions instance)
        {
            if (m_Wrapper.m_UIActionsActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_UIActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public UIActionsActions @UIActions => new UIActionsActions(this);

    // EditorActions
    private readonly InputActionMap m_EditorActions;
    private IEditorActionsActions m_EditorActionsActionsCallbackInterface;
    private readonly InputAction m_EditorActions_Reset;
    public struct EditorActionsActions
    {
        private @InputMaster m_Wrapper;
        public EditorActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Reset => m_Wrapper.m_EditorActions_Reset;
        public InputActionMap Get() { return m_Wrapper.m_EditorActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EditorActionsActions set) { return set.Get(); }
        public void SetCallbacks(IEditorActionsActions instance)
        {
            if (m_Wrapper.m_EditorActionsActionsCallbackInterface != null)
            {
                @Reset.started -= m_Wrapper.m_EditorActionsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_EditorActionsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_EditorActionsActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_EditorActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public EditorActionsActions @EditorActions => new EditorActionsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameplayActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnStomp(InputAction.CallbackContext context);
    }
    public interface IUIActionsActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IEditorActionsActions
    {
        void OnReset(InputAction.CallbackContext context);
    }
}
